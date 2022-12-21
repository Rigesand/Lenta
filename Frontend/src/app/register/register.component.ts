import {Component, OnInit} from '@angular/core'
import {FormBuilder, FormGroup} from '@angular/forms'
import {UserService} from "../services/user.service";
import {Router} from "@angular/router";
import {PersistanceService} from "../services/persistance.service";

@Component({
  selector: 'mc-register',
  templateUrl: 'register.component.html',
  styleUrls: ['register.component.scss'],
})
export class RegisterComponent implements OnInit {
  form: FormGroup

  constructor(
    private fb: FormBuilder,
    public userService: UserService,
    private persistanceService: PersistanceService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      email: '',
      password: '',
      role:''
    })
  }

  onSubmit(): void {
    this.userService.register(this.form.value).subscribe(()=>
    {
      this.persistanceService.set('email',this.form.value.email);
      this.router.navigate(['students']).then(() => {});
    })
  }
}
