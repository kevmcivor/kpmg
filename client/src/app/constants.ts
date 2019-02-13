export class Constants{

  public static ClientId = "js";

  public static StsAuthority = "http://localhost:5000";

  public static ApiRoot =  "https://localhost:44305/api";

  public static ClientRoot = "http://localhost:4200"

  public static AuthRedirectUri = `${Constants.ClientRoot}/user/auth-callback`;

  public static LogoutRedirectUri = `${Constants.ClientRoot}/home`;
}
