//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace projectWith中佑.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServeProblem
    {
        public int serveProblemId { get; set; }
        public int memberId { get; set; }
        public string problemSort { get; set; }
        public string problemTitle { get; set; }
        public string problemContent { get; set; }
        public string problem_time { get; set; }
        public string problemProcess { get; set; }
    
        public virtual Member Member { get; set; }
    }
}
