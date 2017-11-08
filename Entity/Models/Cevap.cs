using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    [Table("tblCevaplar")]
    public class Cevap
    {
        public int CevapID { get; set; }
        [ForeignKey("CevabiVerenKisi")] //bu FK nın dolduracağı virtual Navgation Property CevabiVerenKisi'dir.
        public int KisiID { get; set; }
        [ForeignKey("Sorusu")]
        public int SoruID { get; set; }
        public Yanit Yanit { get; set; }
        public virtual Kisi CevabiVerenKisi { get; set; }
        public virtual Soru Sorusu { get; set; }
    }
    public enum Yanit
    {
        Hayir,
        Evet
    }
}
