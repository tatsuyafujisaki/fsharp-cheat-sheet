module Network

open System.IO
open System.Net.Mail
open System.Net

let sendMail from to1 subject body = 
    use mm = new MailMessage(from, to1, subject, body)
    use sc = new SmtpClient "stmp.example.com"
    sc.Send mm

let ftpDownloadBinary (url : string) (user : string) (password : string) outputPath = 
    let fwr = WebRequest.Create url :?> FtpWebRequest
    fwr.Credentials <- NetworkCredential(user, password)
    use wr = fwr.GetResponse()
    use s = wr.GetResponseStream()
    File.WriteAllBytes(outputPath, U.readAllBytes s)