namespace LeaveManagement.Models
{
    public class Tbl_leave
    {
        public int Id { get; set; }
        public string leave_title { get; set; }
        public string leave_description { get; set; }
        public int leave_type { get; set; }
        public DateOnly from_date { get; set; }
        public DateOnly to_date { get; set; }
        public DateOnly created_date { get; set; }
        public DateOnly updated_date { get; set; }
    }
}
