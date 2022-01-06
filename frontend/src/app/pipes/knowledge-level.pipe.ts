import { Pipe, PipeTransform } from '@angular/core';
import { KnowledgeLevel } from '../models/common/knowledge-level';

@Pipe({
  name: 'knowledgeLevel'
})
export class KnowledgeLevelPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    switch (value as KnowledgeLevel) {
      case KnowledgeLevel.beginer: return 'Beginer'; 
      case KnowledgeLevel.preIntermediate: return 'PreIntermediate'; 
      case KnowledgeLevel.intermediate: return 'Intermediate'; 
      case KnowledgeLevel.upperIntermediate: return 'Upper Intermediate'; 
      case KnowledgeLevel.advanced: return 'Advanced'; 
      case KnowledgeLevel.proficient: return 'Proficient'; 
      default: return 'Beginer';
    }
  }

}
