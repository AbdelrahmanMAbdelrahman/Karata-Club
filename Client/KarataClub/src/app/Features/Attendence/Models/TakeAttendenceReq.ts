export interface TakeAttendenceReq{
    sessionId:string,
    memberAttendence:Record<string,boolean>
}