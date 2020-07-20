using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }
        public string title { set; get; }
        public string description { set; get; }
        public string author_name { set; get; }
        public string publish_time { set; get; }

        public bool published { set; get; }
    }
}
