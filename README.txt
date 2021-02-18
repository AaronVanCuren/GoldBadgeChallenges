Komodo Cafe Komodo cafe is getting a new menu. The manager wants to be able to create new menu items, delete menu items, and receive a list of all items on the cafe's menu. She needs a console app.

The Menu Items: A meal number, so customers can say "I'll have the #5" A meal name A description A list of ingredients, A price

Komodo Claims Department Komodo has a bug in its software and needs some new code.

The Claim has the following properties: ClaimID ClaimType Description ClaimAmount DateOfIncident DateOfClaim IsValid Komodo allows an insurance claim to be made up to 30 days after an incident took place. If the claim is not in the proper time limit, it is not valid.

A ClaimType could be the following: Car Home Theft

Komodo Insurance Komodo Insurance is fixing their badging system.

Here's what they need: An app that maintains a dictionary of details about employee badge information. (Hint: A dictionary is a collection type in C#. You'll want to use that.)

Essentially, an badge will have a badge number that gives access to a specific list of doors. For instance, a developer might have access to Door A1 & A5. A claims agent might have access to B2 & B4.

Your task will be to create the following: A badge class that has the following properties: BadgeID List of door names for access A badge repository that will have methods that do the following: Create a dictionary of badges. The key for the dictionary will be the BadgeID. The value for the dictionary will be the List of Door Names.

The Program will allow a security staff member to do the following: create a new badge update doors on an existing badge. delete all doors from an existing badge. show a list with all badge numbers and door access, like this: Here are some views: Menu

Hello Security Admin, What would you like to do?

Add a badge Edit a badge. List all Badges