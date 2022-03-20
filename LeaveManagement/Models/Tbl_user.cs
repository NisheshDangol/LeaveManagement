namespace LeaveManagement.Models
{
    public class Tbl_user
    {
        public int Id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string contact { get; set; }
        public DateOnly created_date { get; set; }
        public DateOnly updated_date { get; set; }

    }
}
