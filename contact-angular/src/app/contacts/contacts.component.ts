import { Component, inject, OnInit } from '@angular/core';
import { Contact } from '../model/contact.type';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-contacts',
  standalone: true,
  imports: [AsyncPipe, FormsModule, ReactiveFormsModule],
  templateUrl: './contacts.component.html',
  styleUrl: './contacts.component.css',
})
export class ContactsComponent implements OnInit {
  http = inject(HttpClient);
  contacts$ = this.getContact();

  contactsForm = new FormGroup({
    name: new FormControl<string>(''),
    email: new FormControl<string | null>(null),
    number: new FormControl<string>(''),
    favorite: new FormControl<boolean>(false),
  });

  ngOnInit() {}

  constructor() {}

  private getContact(): Observable<Contact[]> {
    return this.http.get<Contact[]>(`https://localhost:7058/api/Contacts`);
  }

  onFormSubmit() {
    // console.log(this.contactsForm.value);
    const addContactRequest = {
      name: this.contactsForm.value.name,
      email: this.contactsForm.value.email,
      number: this.contactsForm.value.number,
      favorite: this.contactsForm.value.favorite,
    };

    this.http
      .post(`https://localhost:7058/api/Contacts`, addContactRequest)
      .subscribe({
        next: (value) => {
          console.log(value);
          this.contacts$ = this.getContact();
          this.contactsForm.reset();
        },
      });
  }

  onDelete(id: string) {
    this.http.delete(`https://localhost:7058/api/Contacts/${id}`).subscribe({
      next: (value) => {
        alert('Item Deleted');
        this.contacts$ = this.getContact();
      },
    });
  }
}
