module Network

open System.Net.Mail

let sendMail from to1 subject body =
    use mm = new MailMessage(from, to1, subject, body)
    use sc = new SmtpClient("stmp.example.com")
    sc.Send mm