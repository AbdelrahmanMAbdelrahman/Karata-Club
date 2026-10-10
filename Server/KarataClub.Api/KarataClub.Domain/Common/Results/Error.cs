namespace KarataClub.Domain.Common.Results;

public  class Error
{
    public Error(string code,string desc,ErrorKind errorKind)
    {
        Code=code;
        Description=desc;
        ErrorKind=errorKind;
    }
    public string Code { get;  }
    public string Description { get;  }
    public ErrorKind ErrorKind { get;  }

    public static Error Conlict(string code= "Error.Conlict", string desc="Conflict")=>new Error(code, desc,ErrorKind.UnExpected);
    public static Error UnAuthorized(string code= "Error.UnAuthorized", string desc= "UnAuthorized") =>new Error(code, desc,ErrorKind.UnAuthorized);
    public static Error NotFound(string code= "Error.NotFound", string desc= "Not Found") =>new Error(code, desc,ErrorKind.NotFound);
    public static Error BadRequest(string code= "Error.BadRequest", string desc= "Bad Request") =>new Error(code, desc,ErrorKind.BadRequest);
    public static Error Validation(string code= "Error.Validation", string desc= "Validation") =>new Error(code, desc,ErrorKind.Validation);
    public static Error UnExpected(string code= "Error.UnExpected", string desc= "UnExpected") =>new Error(code, desc,ErrorKind.UnExpected);
    public static Error Failure(string code= "Error.Failure", string desc= "Failure") =>new Error(code, desc,ErrorKind.Failure);

}
