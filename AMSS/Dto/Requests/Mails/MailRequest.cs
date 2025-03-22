namespace AMSS.Dto.Requests.Mails
{
    public class MailRequest
    {
        public string Subject { get; set; }
        public IEnumerable<MailTo> Tos { get; set; }
        public IEnumerable<MailTo> Bccs { get; set; }
        public IEnumerable<MailTo> Ccs { get; set; }
        public string Content { get; set; }
        public bool IsHtml { get; set; }
        public IEnumerable<MailAttachment> MailAttachments { get; set; }
        public string TemplateName { get; set; }
        public IDictionary<string, string> ContentParameters { get; set; }
    }

    public class MailTo
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class MailAttachment
    {
        public byte[] ByteAttachment { get; set; }
        public string StringAttachment { get; set; }
        public string AttachmentFileName { get; set; }
        public string Type { get; set; }
    }
}
