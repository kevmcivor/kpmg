import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { AngularEditorConfig } from '@kolkov/angular-editor';
import {EditorConfigService} from '../services/editor-config.service';
import { ArticlesClient, ArticleCreateDto } from '../../api.client.generated';

@Component({
  selector: 'app-news-add',
  templateUrl: './news-add.component.html',
  styleUrls: ['./news-add.component.scss']
})
export class NewsAddComponent implements OnInit {

  articleForm: FormGroup;
  editorConfig: AngularEditorConfig;
  submitted = false;

  constructor(
    private fb: FormBuilder,
    private client: ArticlesClient,
    private configService: EditorConfigService) {

    }

  ngOnInit() {
    this.editorConfig = this.configService.config;

    this.articleForm = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(100)]],
      headline: ['', [Validators.required, Validators.maxLength(1000)]],
      body: ['', [Validators.required, Validators.maxLength(4000)]],
      imageUri: ['', [Validators.required, Validators.maxLength(100)]]
    });
  }

  get formControls() { return this.articleForm.controls; }

  onSubmit(value: ArticleCreateDto, valid: boolean) {
    this.submitted = true;
    if (valid) {
      this.client.createArticle(value).subscribe((result) => {
        this.articleForm.reset();
      }, error => console.error(error.response));
    }
  }
}
