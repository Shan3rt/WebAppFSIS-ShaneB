using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace FSISSystem.ENTITIES
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        public int GuardianID { get; set; }
        public int TeamID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        private string _Gender;

        public string Gender//ToUpper
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value.ToUpper();

            }
        }
        public string AlbertaHealthCareNumber { get; set; }

        private string _MedicalAlertDetails;

        public string MedicalAlertDetails
        {
            get
            {
                return _MedicalAlertDetails;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _MedicalAlertDetails = null;
                }
                else
                {
                    _MedicalAlertDetails = value;
                }
            }
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
