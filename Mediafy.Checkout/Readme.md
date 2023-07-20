This is a proof of concept of a checkout application that is expected to go live soon, developed by one of our interns. 

Before launch, there is some feedback from the business side regarding the user input during checkout that needs our attention:
 - Don't always let customers choose country. Offers can generally only be ordered and delivered to contry defined on the Offer. Only exception is the Swedish offer that can be purchased to both Sweden and Finland. 
 - The field Zip Code should be four digits for orders to Norway, five digits for orders to Sweden and Finland.
 - All fields are required, except Norwegian orders that do not require the field Telephone. Please hide this field for Norwegian offers.

 

Assignment: 
 - This project needs to launch within a few days. How should we implement the new business requirements in time, and what code improvements can we manage to include before launch?
 - The project does not follow our normal standards, and we would like to evolve this solution with the goal to be able to reuse the data access and business logic from other clients such as our Android app or an external plugin such as a Mailchimp app. How would we achieve this efficiently?
 - Please review and note down other suggestions of improvements to this project, for example providing more clear separation of concerns, making the code less error prone or improving its readability.
 - Use git and implement the business logic and and some of your suggestions to show how you write code and what you consider important to fix first.
 - Be prepared to discuss details about why you suggest each change, and why you choose some suggestions before others.


 Remarks: 
 - The DataContext is an in memory database, but contains a small set of real world data. Please treat it as our real database for now, we'll switch it to our real database before going live. 
 - The external API that receives orders is out of our control and does not validate orders in the way business wishes. Please keep this in mind.



Spend as much time on this task as you wish, but we expect no more than an hour. Concentrate on what you find most important to show us from a design perspective and to get the application launched in time. Bring the rest to our discussion during the technical interview. 
The deadline is one hour before our interview. Please share the code with us in any way you like. If you use an online platform, make sure you send us a link and make it publicly accessible.
