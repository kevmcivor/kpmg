import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { CommentsClient, CommentDto } from '../../api.client.generated';

@Component({
  selector: 'app-comment-add',
  templateUrl: './comment-add.component.html',
  styleUrls: ['./comment-add.component.scss']
})
export class CommentAddComponent implements OnInit {

  @Input() parentArticleId: number;
  commentForm: FormGroup;
  submitted = false;

  constructor(
    private fb: FormBuilder,
    private client: CommentsClient ) { }

  ngOnInit() {
    this.commentForm = this.fb.group({
      articleId: [this.parentArticleId],
      content: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(1000)]],
    });
  }

  onSubmit(value: CommentDto, valid: boolean) {
    this.submitted = true;
    if (valid) {
      this.client.createComment(value).subscribe(result => {
        this.commentForm.reset();
      }, error => console.error(error.response));
    }
  }
}
