**General Info:**

Hello folks, this repo contains 4 laboratory system projects created with C#.NET and ASTM standards to handle messages thru monodirectional, bidirectional and unidirectional communication protocols. All Windows Applications using RS-232C standard port to listen, read and write data between the laboratory system and the host computer. Also each app includes it's own manual of instructions that describes the type of communication, modes of operation, message format and data transfer with ASCII codes as well as the list of samples to be performed with the laboratory system.


**History and some specs:**

I made those projects 14 years ago when I was 22 years old and to be honest even if the architecture implemented is not the best I feel proud of this achievement because of the difficulty level to understand ASTM standards for each system interface using different TCP/IP mechanisms for transferring data with it's own specifications to setup the data communication protocol occurring between the computer and the instrument. I spent around 2-3 months to build every windows applications using .NET Framework 4 with C# and TSQL to run stored procedures in order to execute CRUD operations, I didn't have to implement so much security because the work environment was placed within an intranet in the private Hospital where I commited this complex task. Notice the root folder contains a db.xml file where you can add/update database parameters using the dataset class to read the local file and get all parameters to put together a connection-string into a variable to use SQL commands, by the way the password parameter is encripted as "admin" using "TripleDES" symmetric algorithm, you can use the same Cryptography class to create your own password.


**About the process and backend structure:**

Of course you will need a database to store your data and perform CRUD operations, however that's up to you, I really wanted to create a database here adding some muckup data but instead I've created a stored procedure to give you an idea about how the entity relational model needs to be done and the base dbo objects needed to understand how those entities are related. Every application was made to fit specs for a laboratory system in charge to perform a variety of tests which means each one of them has a different communication protocol and information proccesing logic to transfer data, so listed below you can see all communication protocols used to transfer data by instrument:

ADVIA120-2120 Hematology System:
  * Bidirectional communication link between the Data Manager software in use on the Hematology System and a laboratory system. This bidirectional link is commonly known as the Host Spec.79 protocol.

SYSMEX XT-2000i/XT-1800i:
  * Bidirectional communication or two way communication which requires acknowledgement response ACK (06H) or NAK (15H) from the host computer.

IMMULITE 1000:
  * Unidirectional LIS specification ASTM E1394.

Dimension XL/RxL:
  * Monodirectional data communication protocol is comprised of two layers of communication occurring between the computer and the instrument.


db - stored procedure example:
![sp_GetUsertData](https://github.com/jassohektor/ASTM-.NET-windows-apps/assets/168608755/5c901330-82cc-4343-ad4c-4976b9d53900)




