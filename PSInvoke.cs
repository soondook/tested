using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading;

namespace tested
{
    class PSInvoke
    {
        public static string RunScript(string scriptText)
        {

            // create Powershell runspace
            Runspace runspace = RunspaceFactory.CreateRunspace();

            // open it
            runspace.Open();

            // create a pipeline and feed it the script text
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);

            // add an extra command to transform the script output objects into nicely formatted strings
            // remove this line to get the actual objects that the script returns. For example, the script
            // "Get-Process" returns a collection of System.Diagnostics.Process instances.
            pipeline.Commands.Add("Out-String");

            // execute the script
            Collection<PSObject> results = pipeline.Invoke();

            // close the runspace
            runspace.Close();

            // convert the script result into a single string
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }
            Console.Write(stringBuilder);
            // return the results of the script that has
            // now been converted to text
            Console.Write(stringBuilder.ToString());
            return stringBuilder.ToString();
        }

        public static string LoadScript(string filename)
        {
            try
            {
                //filename = "C:\\scripts\\PowerShell\\sand_mail.ps1 ";
                // Create an instance of StreamReader to read from our file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(filename))
                {

                    // use a string builder to get all our lines from the file
                    StringBuilder fileContents = new StringBuilder();

                    // string to hold the current line
                    string curLine;

                    // loop through our file and read each line into our
                    // stringbuilder as we go along
                    while ((curLine = sr.ReadLine()) != null)
                    {
                        // read each line and MAKE SURE YOU ADD BACK THE
                        // LINEFEED THAT IT THE ReadLine() METHOD STRIPS OFF
                        fileContents.Append(curLine + "\n");
                    }

                    // call RunScript and pass in our file contents
                    // converted to a string
                    Console.Write(fileContents);
                    return fileContents.ToString();
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                string errorText = "The file could not be read:";
                errorText += e.Message + "\n";
                return errorText;
            }

        }

        public static void PowerNETDOM(string InputStreams)
        {
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                 /*PowerShellInstance.AddScript
                        (
                            "param($Restart,$oldComputerName,$newComputerName,$ADUserPassword,$ADUserName);" +
                            "function ConvertTo-Encoding ([string]$From, [string]$To){" +
                            "   Begin{ $encFrom = [System.Text.Encoding]::GetEncoding($from);$encTo = [System.Text.Encoding]::GetEncoding($to); }" +
                            "   Process{ $bytes = $encTo.GetBytes($_);$bytes = [System.Text.Encoding]::Convert($encFrom, $encTo, $bytes);$encTo.GetString($bytes)}" +
                            "}" +
                            "$tmp = NETDOM RENAMECOMPUTER $oldComputerName /NewName:$newComputerName /ud:$ADUserName /pd:$ADUserPassword /Force $res_text | ConvertTo-Encoding \"cp866\" \"windows-1251\";" +
                            "$tmp > C:\\Temp\\rename.txt;$tmp;"
                        );
                        */

                    PowerShellInstance.AddScript
                        (
                            "param($Data);" +
                            "$rsa = New-Object -TypeName System.Security.Cryptography.RSACryptoServiceProvider;" +
                            "$bytes = [system.Text.Encoding]::UTF8.GetBytes($Data);" +
                            "$encoding = [System.Text.Encoding]::ASCII;" +
                            "$rsa.FromXmlString('<RSAKeyValue><Modulus>qpckDXTWK8imuKMozgNexHnABZLqZ+iI55uNkZ5y1R5eDceIrOEfWUd5V+KIkq+5QepL9upDdnFp4PWUqj++dVR7DcuFMqFQ9DSERsRUr/VxyZ7pDn0xjAPhAmeoe0ffoVnrJAqbhYE5jccsg5+78vrpGPicYH1E7Y+gxq01PuM=</Modulus><Exponent>AQAB</Exponent><P>2aLcuWDVM++oWb75p9eSO6zqmv6K190rAJ4r1SNpcv4FpajhO6+0H1TSeD0Rx3XkNcmPIEVLTom6jhasmSmFdw==</P><Q>yKlFg8RoxzJ7khGKCj6qcObCYlNxaCjiPF5c3TBn5VXaByElJmPCEiODZgbI8FntQE92mZEiHjp/bjb6Zvyc9Q==</Q><DP>A67K12Q5F2Dl02b06I8wTUw2yBqolNCMSr1idn/b5/M+ezgpX44wmRshWKGH7H0lOHfJsT0a8iBIhOEDWLAoLw==</DP><DQ>JgDJBZehMHjDJnrj5eTQaumJTw32oH99uWk1tT6BrtF/pXIFkyu5ia3oKN6IF90wLcne8F6oU4lIsRsAeZjGMQ==</DQ><InverseQ>nA+wqIY5OPnclY2YqW5K4wTpVjZq4s43eKrCwoSKx03aL/oMxMUxpUkQgB/MhEmD78wvZmPCL6dLU1rMWRsxlw==</InverseQ><D>pQZ3Wwkm0s5V8pHsPHdoKvt4tius1X5PSnbhmfhFMEQjSoM3hb52XCDXkxxTcEvMFKb6e8+eGauXeIc6HQRzUmsSFs/xpbNJ4DYkqFYy0cWxENOFWKCSPh9cER1I3OgeM+su+Qj7LozB5ztKL3PEq5xWyfdU+VGCn7WqmR8KWkk=</D></RSAKeyValue>');" +
                            "$encryptedBytes = $rsa.Encrypt($bytes, $true);" +
                             "$encryptedString = [Convert]::ToBase64String($encryptedBytes);" +
                             "$encryptedString.ToString();" +
                             "[String]$OutputFile = 'C:\\temp\\keysRSA.txt';" +
                             "$OutputStream = New-Object IO.FileStream($OutputFile,[IO.FileMode]::Create, [IO.FileAccess]::Write);" +
                             "$writer = New-Object System.IO.StreamWriter $OutputStream, $encoding;" +
                             "$writer.Write($encryptedString);" +
                             "$writer.Dispose();" +
                             "$OutputStream.Dispose();"
                             );
                    //powerShell.AddScript(rootAuthorityScript);
                    PowerShellInstance.AddParameter("Data", InputStreams);

                    //PowerShellInstance.AddParameter("InputStreams", InputStreams.ToString());
                    //PowerShellInstance.AddParameter("Restart", restart);

                    /*PowerShellInstance.AddParameter("restart", restart);
                    PowerShellInstance.AddParameter("newComputerName", newName);
                    PowerShellInstance.AddParameter("oldComputerName", oldName.ToString());
                    PowerShellInstance.AddParameter("ADUserPassword", accountWithPermissions.Password);
                    PowerShellInstance.AddParameter("ADUserName", accountWithPermissions.Domain + "\\" + accountWithPermissions.UserName);
                    */
                    PowerShellInstance.Invoke();
            }

        }

        
        //public static PowerShell PowerShellInstance { get; private set; }
        public static string PowerEDM(string InputStreams)
        {
            string result = "";
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                    PowerShellInstance.AddScript
                    (
                         "param($AesKey, $Data);" +
                         "$Data = [System.Text.Encoding]::UTF8.GetBytes($Data);" +
                         "$AesManaged = New-Object System.Security.Cryptography.AesManaged;"+
                         "$AesManaged.Mode = [System.Security.Cryptography.CipherMode]::CBC;"+
                         "$AesManaged.Padding = [System.Security.Cryptography.PaddingMode]::PKCS7;"+
                         "$AesManaged.BlockSize = 128;"+
                         "$AesManaged.KeySize = 256;"+
                         "$AesManaged.Key = [System.Convert]::FromBase64String($AesKey);"+

                         "$Encryptor = $AesManaged.CreateEncryptor();" +
                         "$EncryptedData = $Encryptor.TransformFinalBlock($Data, 0, $Data.Length);" +
                         "[byte[]] $EncryptedData = $AesManaged.IV + $EncryptedData;" +
                         "$AesManaged.Dispose();" +
                         "[System.Convert]::ToBase64String($AesManaged.IV) > null;" +
                         "$encoding = [System.Text.Encoding]::Unicode;" +
                         "$encryptedString = [System.Convert]::ToBase64String($EncryptedData);" +
                         "$encryptedString.ToString();" +
                         "[String]$OutputFile = 'C:\\temp\\keysRSA2.txt';" +
                         "$OutputStream = New-Object IO.FileStream($OutputFile,[IO.FileMode]::Create, [IO.FileAccess]::Write);" +
                         "$writer = New-Object System.IO.StreamWriter $OutputStream, $encoding;" +
                         "$writer.Write($encryptedString);" +
                         "$writer.Dispose();" +
                         "$OutputStream.Dispose();"+
                         "Write-Output $encryptedString;"
                          );
                //powerShell.AddScript(rootAuthorityScript);
                PowerShellInstance.AddParameter("AesKey", "wQpxkQNAxqULHUsAy/cuTnzyrF1LYGLkbOyozXv6Kag=");
                PowerShellInstance.AddParameter("Data", InputStreams);
                PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();
                outputCollection.DataAdded += outputCollection_DataAdded;
                PowerShellInstance.Streams.Error.DataAdded += Error_DataAdded;
                IAsyncResult results = PowerShellInstance.BeginInvoke<PSObject, PSObject>(null, outputCollection);
                //IAsyncResult results = PowerShellInstance.BeginInvoke(outputCollection);
                if (PowerShellInstance.Streams.Error.Count > 0)
                {
                    // error records were written to the error stream.
                    // do something with the items found.
                }

                while (results.IsCompleted == false)
                {
                    Console.WriteLine("Waiting for pipeline to finish...");
                    
                    Thread.Sleep(100);

                }
                //Console.WriteLine(results.ToString());
                foreach (PSObject outputitem in outputCollection)

                {
                    // if null object was dumped to the pipeline during the script then a null
                    // object may be present here. check for null to prevent potential NRE.
                    if (outputitem != null)
                    {
                        //TODO: do something with the output item 
                        //Console.WriteLine("outputitem:" + outputitem.BaseObject.ToString());
                        //Console.WriteLine(outputitem.BaseObject.GetType().FullName);
                        //var c = outputitem;
                        //animalArrayList.Add(outputitem);
                    }
                    result = outputitem.BaseObject.ToString().Trim();
                    //Console.WriteLine("outputitem:" + outputitem.BaseObject.ToString());
                    //Console.WriteLine(outputItem.BaseObject.ToString() + "\n");
                    //Thread.Sleep(100);
                }
                
            }
            
            return result;

        }

        private static void Error_DataAdded(object sender, DataAddedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void outputCollection_DataAdded(object sender, DataAddedEventArgs e)
        {
            throw new NotImplementedException();
            //Console.WriteLine("Object added to output.");
        }
    }
}
