namespace MaramTX.Models
{
    //indicates the nature and format of a document, file, or assortment of bytes.
    //A MIME type most-commonly consists of just two parts:
    //a type and a subtype, separated by a slash (/) — with no whitespace between:type/subtype
    public static class MimeTypes
    {
        public static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".txt","file/txt" },
                {".docx","file/docx"},
                {".pfx","file/pfx" },
                {".pdf","file/pdf" },
                {".ico","file/ico" }
            };
        }
    }
    //response
}
