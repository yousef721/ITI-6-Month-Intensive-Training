import { Component } from '@angular/core';
import { PostCardVertical } from '../../../../components/post-card-vertical/post-card-vertical';
import { TopicChips } from '../../../../components/topic-chips/topic-chips';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-post-section',
  imports: [PostCardVertical, TopicChips, RouterLink],
  templateUrl: './post-section.html',
  styleUrl: './post-section.css',
})
export class PostSection {}
