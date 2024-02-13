import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterTeacherComponent } from './components/register-teacher/register-teacher.component';
import { RegisterStudentComponent } from './components/register-student/register-student.component';
import { ReactiveFormsModule } from '@angular/forms';
import { YogaClassesComponent } from './components/yoga-classes/yoga-classes.component';
import { DialogsModule } from "@progress/kendo-angular-dialog";
import { ButtonsModule } from "@progress/kendo-angular-buttons";
import { InputsModule } from "@progress/kendo-angular-inputs";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterTeacherComponent,
    RegisterStudentComponent,
    YogaClassesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    DialogsModule,
    ButtonsModule,
    InputsModule,
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
