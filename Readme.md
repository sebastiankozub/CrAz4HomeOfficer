# Creating gists

With GitHub for Visual Studio, you can easily create gists directly from the editor.

1. [Sign in](../getting-started/authenticating-to-github.md) to GitHub.

2. Open a file in the Visual Studio text editor.

3. Select the section of text that you want to create a gist from.

4. Right click and select **Create a GitHub Gist** from the **GitHub** submenu to create the gist on GitHub.

   ![Location of Create a GitHub Gist in the GitHub submenu](images/create-github-gist-menu.png)

5. To create the gist on GitHub Enterprise select **Create an Enterprise Gist** option from the submenu.
    ![Location of Create a Enterprise Gist in the GitHub submenu](images/create-enterprise-gist-menu.png)

6. In the **Create a GitHub Gist** dialog, check that the filename is correct and optionally add a description.

   ![GitHub Gist creation dialog window](images/create-gist-dialog.png)

7. If you want the gist to be private, check the **Private Gist** checkbox.

8. Click **Create**.

9. Once the gist is created it will be opened in your browser.





# Viewing the pull requests for a repository

GitHub for Visual Studio exposes the pull requests for the current repository and lets you create new pull requests and review pull requests from other contributors.

1. [Sign in](../getting-started/authenticating-to-github.md) to GitHub.

2. Open a solution in a GitHub repository.

3. Open **Team Explorer** and click the **Pull Requests** button to open the **GitHub** pane.
![Pull Requests button in the Team Explorer pane](images/pull-requests-button2.png)

4. The open pull requests will be displayed.
![Pull requests in the GitHub pane](images/pull-request-list-view.png)

5. Change the pull requests listed by clicking the **Open** link and selecting the filter you want to use from the dropdown with the options *Open/Closed/All*.
![Pull requests status dropdown filter](images/pull-request-list-filter.png)

6. Filter pull requests by author by clicking the person icon and selecting the user you want to view from the dropdown. You can also search for users from the dropdown.
![Pull requests assignable user dropdown filter](images/pull-request-assignable-user.png)

7. Double-click anywhere in the pull request item to [view the pull request details and review the pull request](reviewing-a-pull-request-in-visual-studio.md)

8. Click on the **Create New** link to [create a pull request from the current branch](creating-a-pull-request.md)





# Cloning a repository to Visual Studio

After you provide your GitHub or GitHub Enterprise credentials to GitHub for Visual Studio, the extension automatically detects the personal, collaborator and organization repositories you have access to on your account.

## Opening the clone dialog

### From **Team Explorer**

Open **Team Explorer** by clicking on its tab next to *Solution Explorer*, or via the *View* menu.
Click the **Manage Connections** toolbar button.

![Location of the manage connections toolbar button in Team Explorer](images/manage-connections.png)

Next to the account you want to clone from, click **Clone**.

![Clone button in the GitHub section of Team Explorer](images/clone-link.png)

### From the **Start Page**

Using Visual Studio 2017, click the `GitHub` button on the `Start Page` to open the clone dialog.

### From the **Start Window**

Using Visual Studio 2019, on the `Start Window` select `Clone or check out code` and then click the `GitHub` button to open the clone dialog.

### From the **File** menu

Go to `File > Open > Open From GitHub...`

## Clone repositories
1. In the list of repositories, scroll until you find the repository you'd like to clone.

You can also filter the repository results by using the *Filter* text box.

In addition to using the list of personal, collaborator and organization repositories, you can enter a repository URL to clone a public repository.

![Unified clone and open dialog](images/unified-clone-dialog.png)

2. If desired, change the local path that the repository will be cloned into, or leave the default as-is.
3. Once a repository is selected and the path is set, Click **Clone**.
4. In Team Explorer, under the list of solutions, double-click on a solution to open it in Visual Studio.

## Open repositories
For any repository that you select from the list or provide a URL for that you already have cloned locally, the **Open** button becomes enabled and a message shows that you have already cloned the repository to that location.

![Open option enabled in clone dialog](images/open-cloned-repository.png)