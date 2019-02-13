import { Component, OnInit, Input } from '@angular/core';
import {FormControl, Validators, FormGroup, FormBuilder} from '@angular/forms';
import { RatingsClient, RatingDto } from '../../api.client.generated';

@Component({
  selector: 'app-rating-add',
  templateUrl: './rating-add.component.html',
  styleUrls: ['./rating-add.component.scss']
})
export class RatingAddComponent implements OnInit {

  @Input() parentArticleId: number;
  ratingForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private client: RatingsClient) { }

  ngOnInit() {
    this.ratingForm = this.fb.group({
      articleId: [this.parentArticleId],
      rate: [0, [Validators.required, Validators.min(1)]],
    });
  }

  toggle() {
    if (this.ratingForm.controls.rate.disabled) {
      this.ratingForm.controls.rate.enable();
    } else {
      this.ratingForm.controls.rate.disable();
    }
  }

  // ngDetroy
  onSubmit(value: RatingDto, valid: boolean) {
    if (valid) {
      this.client.createRating(value).subscribe((result) => {
        this.toggle();
      }, error => console.error(error.response));
    }
  }
}
