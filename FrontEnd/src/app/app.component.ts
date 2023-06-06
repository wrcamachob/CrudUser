import { Component, OnInit, Input} from '@angular/core';
import { Users } from './models/users';
import { UserService } from '../services/user.service';
import { CommondParent } from '../parents/commond-parent';
import { ComponentParent } from '../parents/component-parent';
import { DatePipe, Location } from '@angular/common';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent extends ComponentParent implements OnInit {
  idIdentifier: number | undefined;
  name?: string;
  lastName?: string;
  email: string | undefined;
  phoneNumber: number | undefined;
  dateOfBirthday: Date;
  dateBirth: string;
  usersList: any = [];
  dataset: any = [];
  isNewMaster: boolean = true;
  disableTextbox = false;
  today = new Date().toJSON().split('T')[0];
  angForm: FormGroup;

  constructor(private userService: UserService,
    private formBuilder: FormBuilder,
    private router: Router,
    private location: Location
  ) {
    super();    
    this.dateOfBirthday = new Date();        
    this.createForm();
    //this.usersList = new Users();      
  }
  
  createForm() {
    this.angForm = this.formBuilder.group({
       name: ['', Validators.required ],
       address: ['', Validators.required ]
    });
  }

  ngOnInit() {    
    this.CleanData();
    this.InitAutocomplete();
  }

  ValResult(data: any, error: any) {
    if (data != "" && data != null) {
      this.isNewMaster = false;
      this.alertOk(data, 'User');       
    } else if(error != "" && error != null){
      this.alertError('Error in data', 'Error');
    } else {
      //this.errorHandled(data['message']);
    }
  }

  InitAutocomplete() {
    this.userService.GetList().subscribe(
      data => {
        if (data) {
          this.usersList = data;
          console.log(this.usersList)
        }
      });
  }

  selectedUser: Users = new Users();

  addOrEdit() {
    if (this.selectedUser.idIdentifier === 0) {
      this.selectedUser.idIdentifier = this.usersList.length + 1;
      this.usersList.push(this.selectedUser);
    }

    this.selectedUser = new Users();
  }

  Save() {
    if (confirm('Are you sure you want to save it?')) {
      const params = {
        idIdentifier: this.idIdentifier,
        name: this.name,
        lastname: this.lastName,
        email: this.email,
        phoneNumber: this.phoneNumber,
        dateOfBirthday: this.dateBirth
      };      
      if (this.isNewMaster) {        
        this.userService.Insert(params)
        .subscribe({
          next: (data: any) => {
            this.ValResult(data, null);
            this.ngOnInit();
          },
          error: (response : any) => {
            this.ValResult(null,response);            
            console.log(response.error);
          }
        });        
      } else {
        this.userService.Update(params)
        .subscribe({
          next: (data: any) => {
            this.ValResult(data, null);
            this.ngOnInit();
          },
          error: (response : any) => {
            this.ValResult(null,response);            
            console.log(response.error);
          }
        });
      }
    }
  }

  openForEdit(user: Users) {
    this.isNewMaster = false;
    const datePipe = new DatePipe('en-US')
    const formattedDate = datePipe.transform(user.dateOfBirthday, 'yyyy-MM-dd')
    this.selectedUser = user
    this.idIdentifier = user.idIdentifier
    this.name = user.name
    this.lastName = user.lastName
    this.email = user.email
    this.phoneNumber = user.phoneNumber
    this.dateBirth = formattedDate! //user.dateOfBirthday //moment(user.dateOfBirthday).format("dd-MM-yyyy") //user.dateOfBirthday //this.formatDateHttpGet(user.dateOfBirthday.jsdate) //moment(user.dateOfBirthday).format("yyyy-MM-dd")
    this.disableTextbox = true;
  }

  delete() {
    if (confirm('Are you sure you want to delete it?')) {
      this.userService.Delete(this.idIdentifier!)
        .subscribe({
          next: (data: any) => {
            this.ValResult(data, null);
            this.ngOnInit();
          },
          error: (response: any) => {
            this.ValResult(null, response);
            console.log(response.error);
          }
        });
      this.selectedUser = new Users();
    }
  }

  CleanData() {
    this.isNewMaster = true;
    this.disableTextbox = false;
    this.idIdentifier = undefined;
    this.name = "";
    this.lastName = "";
    this.email = "";
    this.phoneNumber = undefined;
    this.dateBirth = "";
  }

  keyPressNumbers(event: any) {
    var charCode = (event.which) ? event.which : event.keyCode;
    // Only Numbers 0-9
    if ((charCode < 48 || charCode > 57)) {
      event.preventDefault();
      return false;
    } else {
      return true;
    }
  }
}
