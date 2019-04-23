import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Hair } from './hair';

export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const hairs = [

      { id: 15, name: 'Pixie Cut' },
      { id: 16, name: 'Shag' },
      { id: 17, name: 'Bob' },
      { id: 18, name: 'Layered' },
      { id: 19, name: 'Long Layered' },
      { id: 20, name: 'Short Layered' },
      { id: 21, name: 'French Twists' },
      { id: 22, name: 'Half Up' },
      { id: 23, name: 'Twists' },
      { id: 24, name: 'Braids Hair' },
      { id: 25, name: 'Multicolored'},
      { id: 26, name: 'Brown'},
      { id: 27, name: 'Bright Colors'},
      { id: 28, name: 'Black'},
    ];
    return {hairs};
  }

  
  genId(hairs: Hair[]): number {
    return hairs.length > 0 ? Math.max(...hairs.map(hair => hair.id)) + 1 : 11;
  }
}
