namespace LeaveManagement.Models
{
    public class Tbl_leavetype
    {
        public int Id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public DateOnly created_date { get; set; }
        public DateOnly updated_date { get; set; }
    }
}
