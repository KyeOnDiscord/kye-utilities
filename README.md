# Kye Utilities

<h2> Features</h2>

<h3>KyeBool</h3> 

    KyeBool.HasInternet() - Returns True if the person can connect to google.com
    KyeBool.RandomBool() - Returns a random boolean (True/False)
    

**</h3>KyeFunction</h3>**

	KyeFunction.sendDiscordWebhook(string URL, string profilepicurl, string username, string message); - Sends a Discord webhook
	KyeFunction.CheckForMalicious(); - Checks if anything for HTTP Debugging is runner (Fiddler)
	KyeFunction.CheckMD5(string url with md5, string [Optional] msg to show if program doesn't match md5); - First string is to put a url which contains the MD5 you want your program to match with, the second string is optional and it's the msg to show if the program has been modified, leave this blank if you want.
	KyeFunction.DeleteFile(string filename) - Checks if a file exists and deletes it
	KyeFunction.WriteLine(string filepath, string new text, int line number to edit) - Edits a text file by replacing a specific line with new text.
**</h3>KyeInt</h3>**

    KyeInt.RandomInt(int min, int max) - Returns a random integer between the minimum and maximum set values
    KyeInt.GetGPUCount() - Gets how many GPU's are in your PC's hardware (Should be accurate however, it has only been tested on 1 PC)

**KyeString**

    KyeString.GetIP() - Returns the user's current IP Address
    KyeString.GetCountry() - Returns the user's country based on their IP Address
    KyeString.GetHWID() - Gets the user's HWID in Sha256 (Uses Machine GUID & CPU ID)
    KyeString.RandomString(int length) - Returns a random string with the length specified
    KyeString.RandomStringWithoutNumbers(int length) - Returns a random string without numbers at the length specified.
    KyeString.Encodebase64(string TextToEncode) - Returns text encoded in Base64
    KyeString.DecodeBase64(string base64EncodedData) - Returns text from which was Encoded in Base64
    KyeString.GetMD5(string filename) - Returns the MD5 of the specified file
    KyeString.GetThisMD5() - Return's the program's MD5
    KyeString.InstalledRAM() - Returns the user's RAM installed on their Hardware, returns e.g: 15.86GB
    KyeString.GetGPU() - Returns a string array of the user's GPUs. E.g: KyeString.GetGPU()[0]) would return as Intel(R) UHD Graphics 630. KyeString.GetGPU()[1] would return as NVIDIA GeForce GTX 1650.
    KyeString.ReadLine(string fileName, int line) - Returns the text in a specific line in a text file.
