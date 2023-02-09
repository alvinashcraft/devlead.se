﻿return await Bootstrapper
    .Factory
    .CreateDefault(args)
    .AddThemeFromUri(new Uri("https://github.com/devlead/CleanBlog/archive/5eb1381346e550db6e1fbd4e268889dbc1dfcee.zip"))
    .AddWeb()
    .AddTabGroupShortCode()
    .AddIncludeCodeShortCode()
    .ConfigureSettings(settings =>
    {
        settings["GitHubBranch"] = Config.FromSetting<string>("GH_BRANCH", "main");
    })
    .DeployToGitHubPages(
        Config.FromSetting<string>("GH_OWNER","devlead"),
        Config.FromSetting<string>("GH_REPO", "devlead.github.io"),
        Config.FromSetting<string>("DEVLEADSE_GITHUB_TOKEN")
    )
    .RunAsync();
