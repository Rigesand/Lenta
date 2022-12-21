import {Component, OnInit} from '@angular/core'
import {FormBuilder, FormGroup} from '@angular/forms'
import {UserService} from "../services/user.service";
import {PersistanceService} from "../services/persistance.service";
import {Router} from "@angular/router";

@Component({
  selector: 'mc-login',
  templateUrl: 'login.component.html',
  styleUrls: ['login.component.scss'],
})
export class LoginComponent implements OnInit {
  form: FormGroup

  constructor(private fb: FormBuilder,
              private userService:UserService,
              private persistanceService: PersistanceService,
              private router: Router) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      email: '',
      password: '',
    })
  }


  onSubmit(): void {
    this.persistanceService.set('email',this.form.value.email);
    this.userService.login(this.form.value).subscribe((value)=>
    {
      this.router.navigate(['students']).then(() => {});
    })
  }
}
