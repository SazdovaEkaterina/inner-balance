import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginModel } from '../models/login';
import { RegisterStudentModel } from '../models/register-student';
import { RegisterTeacherModel } from '../models/register-teacher';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(
    @Inject(HttpClient) private readonly httpClient: HttpClient
  ) { }

  public login(loginModel: LoginModel): Observable<(any)> {
    return this.httpClient.post<(any)>('https://localhost:7057/api/authentication/login', loginModel);
  }

  public registerTeacher(registerTeacherModel: RegisterTeacherModel): Observable<boolean> {
    return this.httpClient.post<boolean>('https://localhost:7057/api/authentication/register-teacher', registerTeacherModel);
  }

  public registerStudent(registerStudentModel: RegisterStudentModel): Observable<boolean> {
    return this.httpClient.post<boolean>('https://localhost:7057/api/authentication/register-student', registerStudentModel);
  }
}
