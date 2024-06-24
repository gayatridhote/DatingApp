namespace api.Extensions
{
    public static class DateTimeExtentions
    {
        public static int CalculateAge(this DateTime dob) 
        {
            var today = DateTime.UtcNow;
            var age = today.Year -dob.Year;
            if (dob > today.AddYears(-age)) age--;
            return age;
        }  
        
    }

//     public class DateOnlyToDateTimeConverter : ITypeConverter<DateOnly, DateTime>
// {
//     public DateTime Convert(DateOnly source, DateTime destination, ResolutionContext context)
//     {
//         return source.ToDateTime(TimeOnly.MinValue); // Convert DateOnly to DateTime
//     }
// }
}