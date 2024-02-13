import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterTeacherComponent } from './components/register-teacher/register-teacher.component';
import { RegisterStudentComponent } from './components/register-student/register-student.component';
import { AppComponent } from './app.component';
import { YogaClassesComponent } from './components/yoga-classes/yoga-classes.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register-teacher',
    component: RegisterTeacherComponent
  },
  {
    path: 'register-student',
    component: RegisterStudentComponent
  },
  {
    path: 'yoga-classes',
    component: YogaClassesComponent
  },
  {
    path: '',
    component: AppComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
