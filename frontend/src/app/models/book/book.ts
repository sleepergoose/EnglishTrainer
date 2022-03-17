import { KnowledgeLevel } from "../common/knowledge-level";

export interface Book {
  id: number;
  name: string;
  author: string
  description: string;
  level: KnowledgeLevel;
  blobId: string;
}