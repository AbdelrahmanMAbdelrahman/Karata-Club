export interface TakeAttendenceReq{
    sessionId:string,
    memberAttndence:Map<string,boolean>
}