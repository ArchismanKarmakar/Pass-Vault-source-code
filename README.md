# Pass-Vault-source-code
## _Edited with Visual Studio Code, edited by Archisman Karmakar_


[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

### Pass Vault is a Open Source Offline Password Manager that works using some custom & in-build libraries. It uses AES256 & SHA256 algos to store data in a AccessDatabase File

# Get Started
## Prerequisites
- Microsoft Access  Database Engine (x86)
- Microsoft DOT NET SDK & Runtime 4.8
- Visual Studio (2015 or higher)

## ISSUES
- ##### Multiple User accounts not available. Add feature for setting up Multiple User accounts. ![]() ![](https://img.shields.io/badge/Difficulty-Extreme-red)
- ##### Encryption key is applied in code. Reverse engineering can reveal the key. Use DPAPI to securely store keys in user hardware (TPM). ![]() ![](https://img.shields.io/badge/Difficulty-Extreme-red)
- ##### Proper locked backup system for each database. ![]() ![](https://img.shields.io/badge/Difficulty-Moderate-yellow)
- ##### The GUI is very bad. Flashing screen is very common. Improve the GUI. ![]() ![](https://img.shields.io/badge/Difficulty-Moderate-yellow)
- ##### Fix the searching of records problem. ![]() ![](https://img.shields.io/badge/Difficulty-Hard-orange)

## Extra Tasks
- ##### Convert the project to C# and C++ libraries. ![]() ![](https://img.shields.io/badge/Difficulty-Extreme-red)
- ##### Add card system for each credential. ![]() ![](https://img.shields.io/badge/Difficulty-Easy-green)
- ##### Add a section in left pane that is hidable and add various accessible menus and items there. ![]() ![](https://img.shields.io/badge/Difficulty-Easy-green)
- ##### Add a Recycle bin feature there. ![]() ![](https://img.shields.io/badge/Difficulty-Moderate-yellow)
- ##### Add Secure String Input feature. ![]() ![](https://img.shields.io/badge/Difficulty-Easy-green)
- ##### Add Virtual Keyboard. ![]() ![](https://img.shields.io/badge/Difficulty-Easy-green)
- ##### Add File attachment feature with each record. ![]() ![](https://img.shields.io/badge/Difficulty-Hard-orange)
- ##### Add In-build Notes Keeper. ![]() ![](https://img.shields.io/badge/Difficulty-Moderate-yellow)
- ##### Add Anti-Tamper Protection of Source code. ![]() ![](https://img.shields.io/badge/Difficulty-Extreme-red)
- ##### Use auto compression of files to reduce size. ![]() ![](https://img.shields.io/badge/Difficulty-Hard-orange)
- ##### Autofill feature for browsers and other apps. ![]() ![](https://img.shields.io/badge/Difficulty-Moderate-yellow)
- ##### Browser & Windows Power Shell Integration. ![]() ![](https://img.shields.io/badge/Difficulty-Hard-orange)

## Installation

Download Visual Studio 2015 or higher to get started.

Get Microsoft Access database engine x86 and .NET Framework 4.8.0 Runtime & SDK and install them.

Install the dependencies, load the project and first job is to disable ClickOnce App Signing, removing security certificates. Now Just set .NET Framework 4.8 & enjoy coding!

```NOTE:``` Please check out the File_Tree_View.txt file to get some idea about the file structure and contents of the project.

### Editing the Password Database File

All the databases are ACCDB files only the extensions have been changed. The Passwords for the database files are listed below (I don't remember in which files I applied it, but I kept these 2 passwords and applied only these 2): 

#### ```CONFIDENTIAL:``` 
- 1: tmzS~u%sw<n6&rs3e^9&
- 2: cw?b5j_oS<gUg3u_2wSl

## Setting up softwares

To work on Github hosted projects, one has to use Git - a Version Control System. So the first task is to install git on your machine. For Windows users, download git from here - https://git-scm.com/downloads. For Linux users, you can use your distro's package manager to install git.

**Note:** Although Linux isn't mandatory, it is preferred while working with Open Source Software.

**Note:** You can learn about Version Control Systems (VCS) [here](https://www.atlassian.com/git/tutorials/what-is-version-control).

## Setting up git

After installing git, run git and execute these commands:

```
git config --global user.name "[name]"
git config --global user.email "[email address]"
```

That should complete the software setup.

## Forking and Cloning

Before you can edit any file on the repo, you must fork and clone it. A **fork** is a copy of the repository in your account. To **clone** a repo means to download it locally. Click the Fork button on the top right of this repo to fork it. Next, go to your copy of the repo and click the Clone button. Copy the url. Now open git and execute this command:

```
git clone [copied url here]
```

That should download the repo locally.

## Making branches

A **branch** is a parallel copy of the code. When we add new features to a project, we usually create a copy of the code and work on it. This is done so that the main working copy of the code is unaffected. In most GitHub repos, the master branch is the default branch. You should create a separate branch for every contribution you make. To create a new branch, execute this command:

```
git checkout -b [branch name here]
```

You should see the branch name change on the terminal prompt. Congratulations! You created a new branch.


## Edit/Add files

## Adding and commiting changes

To create a **commit** means to save your work. But before you commit, you have to **add** your work to the commit. To do so, execute this command from the project root:

```
git add *
```

This adds all files to the upcoming commit. Now, to create the commit run this command:

```
git commit -m "[commit message here]"
```

Write any message in place of the commit message. If the command runs successfully, you should have committed your changes.

## Pushing changes and submitting a Pull Request

After committing your changes, you have to upload them to GitHub. This is known as **pushing**. To push your changes, run:

```
git push origin [branch name]
```

Where branch name is the name of your newly created branch. This should upload your changes to *your* GitHub account. Now, you can propose these changes to the actual project. To do so, click on the **Pull Request** button on GitHub. Most of the fields should be automatically filled out for you. Click Create Pull Request. If everything went correctly, you should have created a pull request with your changes. Now it is upto the repo owner to **merge** these changes.

Congratulations! You made your first Open Source Contribution! Now contribute to some other repos. Have a great time!

# Resources

You can learn more about Git and GitHub here:

- https://www.youtube.com/watch?v=w3jLJU7DT5E
- https://codeburst.io/a-step-by-step-guide-to-making-your-first-github-contribution-5302260a2940




## Plugins

```Empty```

## Development

```Empty```

## License

MIT

**Free Software, Hell Yeah!**

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

   [dill]: <https://github.com/joemccann/dillinger>
   [git-repo-url]: <https://github.com/joemccann/dillinger.git>
   [john gruber]: <http://daringfireball.net>
   [df1]: <http://daringfireball.net/projects/markdown/>
   [markdown-it]: <https://github.com/markdown-it/markdown-it>
   [Ace Editor]: <http://ace.ajax.org>
   [node.js]: <http://nodejs.org>
   [Twitter Bootstrap]: <http://twitter.github.com/bootstrap/>
   [jQuery]: <http://jquery.com>
   [@tjholowaychuk]: <http://twitter.com/tjholowaychuk>
   [express]: <http://expressjs.com>
   [AngularJS]: <http://angularjs.org>
   [Gulp]: <http://gulpjs.com>

   [PlDb]: <https://github.com/joemccann/dillinger/tree/master/plugins/dropbox/README.md>
   [PlGh]: <https://github.com/joemccann/dillinger/tree/master/plugins/github/README.md>
   [PlGd]: <https://github.com/joemccann/dillinger/tree/master/plugins/googledrive/README.md>
   [PlOd]: <https://github.com/joemccann/dillinger/tree/master/plugins/onedrive/README.md>
   [PlMe]: <https://github.com/joemccann/dillinger/tree/master/plugins/medium/README.md>
   [PlGa]: <https://github.com/RahulHP/dillinger/blob/master/plugins/googleanalytics/README.md>
