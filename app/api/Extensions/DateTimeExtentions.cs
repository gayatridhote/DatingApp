namespace api.Extensions
{
    public static class DateTimeExtentions
    {
        public static int CalculateAge(this DateTime dob) 
        {
            var today = DateTime.Now;
            var age = today.Year -dob.Year;
            if (dob > today.AddYears(-age)) age--;
            return age;
        }  
        
    }
}

