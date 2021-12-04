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
- ##### Fix the searching of records problem. ![]() ![](https://img.shields.io/badge/Difficulty-Moderate-yellow)

## Extra Tasks
- ##### Convert the project to C# and C++ libraries. ![]() ![](https://img.shields.io/badge/Difficulty-Extreme-red)
- ##### Add card system for each credential. ![]() ![](https://img.shields.io/badge/Difficulty-Easy-green)
- ##### Add a section in left pane that is hidable and add various accessible menus and items there. ![]() ![](https://img.shields.io/badge/Difficulty-Easy-green)
- ##### Add a Recycle bin feature there. ![]() ![](https://img.shields.io/badge/Difficulty-Moderate-yellow)
- ##### Add Secure String Input feature. ![]() ![](https://img.shields.io/badge/Difficulty-Easy-green)
- ##### Add Virtual Keyboard. ![]() ![](https://img.shields.io/badge/Difficulty-Easy-green)
- ##### Add File attachment feature with each record. ![]() ![](https://img.shields.io/badge/Difficulty-Moderate-yellow)
- ##### Add In-build Notes Keeper. ![]() ![](https://img.shields.io/badge/Difficulty-Moderate-yellow)
- ##### Add Anti-Tamper Protection of Source code. ![]() ![](https://img.shields.io/badge/Difficulty-Extreme-red)
- ##### Use auto compression of files to reduce size. ![]() ![](https://img.shields.io/badge/Difficulty-Extreme-red)
- ##### Autofill feature for browsers and other apps. ![]() ![](https://img.shields.io/badge/Difficulty-Moderate-yellow)
- ##### Browser & Windows Power Shell Integration. ![]() ![](https://img.shields.io/badge/Difficulty-Moderate-yellow)

## Installation

Download Visual Studio 2015 or higher to get started.

Get Microsoft Access database engine x86 and .NET Framework 4.8.0 Runtime & SDK and install them.

Install the dependencies, load the project and first job is to disable ClickOnce App Signing, removing security certificates. Now Just set .NET Framework 4.8 & enjoy coding!

```NOTE:``` Please check out the File_Tree_View.txt file to get some idea about the file structure and contents of the project.

### Editing the Password Database File

All the databases are ACCDB files only the extensions have been changed. The Passwords for the database files are listed below (I don't remember in which files I applied it, but I kept these 2 passwords and applied only these 2): 
```CONFIDENTIAL:``` 
1: tmzS~u%sw<n6&rs3e^9&
2: cw?b5j_oS<gUg3u_2wSl

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
