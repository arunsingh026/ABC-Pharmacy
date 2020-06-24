import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'medicine-component',
  templateUrl: './medicine.component.html'
})
export class MedicineComponent {

  medicineForm: FormGroup;
  result: any;
  @Inject('BASE_URL') baseUrl: string;
  constructor(private fb: FormBuilder, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.medicineForm = this.fb.group({
      fullName: ['', Validators.required],
      brand: ['', Validators.required],
      price: ['', [Validators.required, Validators.pattern('^[0-9]*\$')]],
      quantity: ['', [Validators.required, Validators.pattern('^[0-9]*\$')]],
      expiryDate: ['', Validators.required],
      notes: [''],
    });
  }

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.warn(this.medicineForm.value);
    this.http.post('pharmacy', this.medicineForm.value).subscribe(data => {
      this.result = data;
      this.ngOnInit();
    }, error => { console.log("Error", error); });
  }
}
