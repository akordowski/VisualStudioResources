/* ---------------------------------------------------------------------------------------------------- */
/* ARGUMENTS */

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var visualStudioVersion = Argument("visualStudioVersion", "2015");
var lcid = Argument("lcid", "1033");


/* ---------------------------------------------------------------------------------------------------- */
/* CONSTANTS */

var PROJECT = "VisualStudioResources";
var PROJECT_DIR = Context.Environment.WorkingDirectory.FullPath + "/";
var IMAGE_DIR = PROJECT_DIR + "artifacts/image/";
var PACKAGE_DIR = PROJECT_DIR + "artifacts/package/";


/* ---------------------------------------------------------------------------------------------------- */
/* HELPER METHODS - BUILD */

void BuildProject(string projectPath, string configuration)
{
    BuildProject(projectPath, configuration, MSBuildPlatform.Automatic);
}

void BuildProject(string projectPath, string configuration, MSBuildPlatform buildPlatform)
{
    if(IsRunningOnWindows())
    {
        // Use MSBuild
        MSBuild(projectPath, new MSBuildSettings()
            .SetConfiguration(configuration)
            .SetMSBuildPlatform(buildPlatform)
            .SetVerbosity(Verbosity.Minimal)
            .SetNodeReuse(false)
        );
    }
    else
    {
        // Use XBuild
        XBuild(projectPath, new XBuildSettings()
            .WithTarget("Build")
            .WithProperty("Configuration", configuration)
            .SetVerbosity(Verbosity.Minimal)
        );
    }
}


/* ---------------------------------------------------------------------------------------------------- */
/* HELPER METHODS - PACKAGE */

void CopyItemTemplates(string lcid)
{
    var dirs = GetDirectories(PROJECT_DIR + "ItemTemplates/" + lcid + "/*");

	foreach(var dir in dirs)
	{
	    var section = new DirectoryInfo(dir.FullPath).Name;
	    var sectionDir = IMAGE_DIR + "/" + lcid + "/ItemTemplates/" + section;
	    var projectDirs = GetDirectories(dir + "/*");

	    CreateDirectory(sectionDir);

	    foreach(var projectDir in projectDirs)
	    {
	    	var project = new DirectoryInfo(projectDir.FullPath).Name;
	    	var fileSource = projectDir + "/bin/Release/ItemTemplates/CSharp/1033/" + project + ".zip";
	    	var fileTarget = sectionDir + "/" + project + ".zip";

	    	CopyFile(fileSource, fileTarget);
	    }
	}
}

void CopySnippets(string lcid)
{
    var sourceDir = PROJECT_DIR + "Snippets/" + lcid + "/";
    var targetDir = IMAGE_DIR + "/" + lcid + "/Snippets/";

    CopyDirectory(sourceDir, targetDir);
}


/* ---------------------------------------------------------------------------------------------------- */
/* BUILD */

Task("Build")
    .Does(() =>
    {
        BuildProject(string.Format("{0}.sln", PROJECT), configuration);
    });


/* ---------------------------------------------------------------------------------------------------- */
/* DEPLOY */

Task("Deploy")
	.IsDependentOn("Build")
	.IsDependentOn("CreateImage")
    .Does(() =>
    {
        var userProfile = EnvironmentVariable("USERPROFILE");
        var visualStudioDir = userProfile + "/Documents/Visual Studio " + visualStudioVersion + "/";

        var itemTemplatesTargetDir = visualStudioDir + "Templates/ItemTemplates/Visual C#/ItemTemplates/";
        var projectsTemplatesTargetDir = visualStudioDir + "Templates/ProjectTemplates/Visual C#/";
        var snippetsTargetDir = visualStudioDir + "Code Snippets/Visual C#/My Code Snippets/";

		var itemTemplatesSourceDir = IMAGE_DIR + lcid + "/ItemTemplates/";
		var projectsTemplatesSourceDir = IMAGE_DIR + lcid + "/ProjectTemplates/";
        var snippetsSourceDir = IMAGE_DIR + lcid + "/Snippets/";

        CopyDirectory(itemTemplatesSourceDir, itemTemplatesTargetDir);
        CopyDirectory(snippetsSourceDir, snippetsTargetDir);
    });


/* ---------------------------------------------------------------------------------------------------- */
/* PACKAGE */

var LCIDs = new string[] { "1031","1033" };
var Resources = new string[] { "ItemTemplates","Snippets" };

Task("CreateImage")
    .Does(() =>
    {
        CreateDirectory(IMAGE_DIR);
        CleanDirectory(IMAGE_DIR);

        foreach(string lcid in LCIDs)
        {
        	CopyItemTemplates(lcid);
        	CopySnippets(lcid);
        }
    });

Task("PackageZip")
    .IsDependentOn("CreateImage")
    .Does(() =>
    {
        CreateDirectory(PACKAGE_DIR);
        CleanDirectory(PACKAGE_DIR);

        foreach(string lcid in LCIDs)
        {
        	var zipSource = IMAGE_DIR + lcid;
        	var zipTarget = PACKAGE_DIR + lcid + ".zip";

        	Zip(zipSource, zipTarget);
        }
    });


/* ---------------------------------------------------------------------------------------------------- */
/* TASK TARGETS */

Task("Default")
    .IsDependentOn("Build");

Task("Package")
	.IsDependentOn("Build")
    .IsDependentOn("PackageZip");


/* ---------------------------------------------------------------------------------------------------- */
/* EXECUTION */

RunTarget(target);