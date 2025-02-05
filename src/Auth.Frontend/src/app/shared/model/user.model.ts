export interface IUserLogin {
    userName: string;
    password: string;
}

export interface IRegisterUser extends IUserLogin {
    email: string;
}

export type SubmitedUser = IUserLogin | IRegisterUser;

export interface IUser{
    username: string;
    role: string;
}

export interface IUserInfo  extends IUser {
    email: string;
}