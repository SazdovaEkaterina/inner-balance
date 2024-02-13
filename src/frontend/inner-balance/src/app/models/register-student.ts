import { Membership } from "./membership";

export interface RegisterStudentModel {
    firstName: string,
    lastName: string,
    userName: string,
    email: string,
    password: string,
    membership: Membership,
}