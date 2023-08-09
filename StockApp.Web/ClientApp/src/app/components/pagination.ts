
export class PaginationComponent{
    total = 0;
    count = 30;
    page = 1;

  resetPage() {
    this.page = 1;
    this.total = 0;
  }
}
