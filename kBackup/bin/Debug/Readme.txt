Features
The app currently has a number of features and may be expanded to include additional features if 
the demand is there.
•	The app will back up your help center or web portal content to a specified folder as html 
	pages in the format of [ArticleId].html. The app will first verify that the user exists in 
	the given Zendesk domain. This is included for security reasons so only users who exist in 
	the domain can back up the content.
•	The app will work for any Zendesk help center or web portal even if you chose to use the 
	Host Mapping feature as the original Zendesk sub-domain will still exist, regardless of 
	what you have currently set as your hostname.
•	Using the app to backup your help center or web portal content is completely safe and will 
	not affect any existing data, it will simply take a copy of it so there is no possibility 
	for data loss during the process.

Requirements
There are some requirements for using this app that need to be met in order for it to function 
correctly. I've included these requirements below:
•	This program is only compatible with Windows PC's and Laptops only.
•	Your user must have ‘Password Access’ to the API enabled in Zendesk. You can do this by 
	going to Settings > Channels > API and checking the ‘Password Access’ check box.
•	The app requires Microsoft .Net Framework 4.6 to be installed on the Windows PC or Laptop 
	where it’s being run, this version of the .Net Framework can be downloaded here 
	(https://www.microsoft.com/en-ie/download/details.aspx?id=48130)
•	I recommend running the app as Administrator to avoid any permission issues backing up to 
	your selected backup location. This can be done by right-clicking the kBackup.exe and 
	selecting ‘Run as administrator’.

Getting Started
To get started with backing up your help center content ensure that you have met the requirements 
above, then go ahead and follow the steps below:
1.	Download a copy of the app here (http://dstats.net/download/http:/www.fail2reap.com/downloads/kbackup.zip)
2.	Extract the downloaded kBackup.zip file to your Desktop
3.	Right click the app and select 'Run as administrator’
4.	Enter your Zendesk sub-domain into the Domain field
5.	Enter your Zendesk users email into the Email field
6.	Enter your Zendesk users’ password into the Password field
7.	Select Help Center or Web Portal depending on which you are using
8.	Select the Backup button
9.	Browse for a folder where you would like to back up your content and select Ok 

The backup will then begin. This may take a few minutes so why not grab a cup of coffee or a 
quick snack and you will receive a pop-up message from kBackup once your backup is complete.
