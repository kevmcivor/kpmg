import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

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
    private router: Router,
    private client: ArticlesClient,
    private configService: EditorConfigService) {

    }

  ngOnInit() {
    this.editorConfig = this.configService.config;

    this.articleForm = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(100)]],
      headline: ['', [Validators.required, Validators.maxLength(1000)]],
      body: ['', [Validators.required, Validators.maxLength(4000)]],
      imageUri: ['', [Validators.required, Validators.maxLength(100)]],
      publicationDate: ['', [Validators.required, Validators.maxLength(100)]]
    });
  }

  redirectToView(articleId: number) {
    this.router.navigate(['/news', articleId]);
  }

  get formControls() { return this.articleForm.controls; }

  onSubmit(article: ArticleCreateDto, valid: boolean) {
    this.submitted = true;
    if (valid) {
      this.client.createArticle(article).subscribe((result) => {
        this.articleForm.reset();
        this.redirectToView(result.id);
      }, error => console.error(error.response));
    }
  }
}
