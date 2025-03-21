namespace Business.ReturnType
{
    public class CreateUserResult
    {
        public bool Success { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }

}
