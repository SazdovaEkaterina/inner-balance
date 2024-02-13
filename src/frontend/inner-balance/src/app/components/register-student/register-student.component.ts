import { Component, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DropdownItem } from 'src/app/models/dropdown-item';
import { RegisterStudentModel } from 'src/app/models/register-student';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'ib-register-student',
  templateUrl: './register-student.component.html',
  styleUrls: ['./register-student.component.scss']
})
export class RegisterStudentComponent {
  public formGroup: FormGroup = this.formBuilder.group({});
  public memberships: DropdownItem[] = [
    {
      value: 0,
      name: 'Basic',
    },
    {
      value: 1,
      name: 'Premium',
    },
  ]

  constructor(
    @Inject(FormBuilder) private readonly formBuilder: FormBuilder,
    @Inject(AuthenticationService) private readonly authenticationService: AuthenticationService,
    ) {
  }

  ngOnInit(): void {
    this.buildForm();
  }

  public submit() {
    const payload = this.formGroup.getRawValue() as RegisterStudentModel;
    this.authenticationService.registerStudent(payload).subscribe(result => {
      console.log(result);
    })
  }

  private buildForm() {
    this.formGroup = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      userName: ['', [Validators.required]],
      email: ['', [Validators.required]],
      password: ['', [Validators.required]],
      membership: [0],
    });
  }
}
