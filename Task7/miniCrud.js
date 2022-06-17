class Storage {
    constructor() {
      this.list = [];
    }
    add(newElement) {
      this.list.push(newElement);
    }
    getById(id){
      return this.list[id];
    }
    getAll(){
        return this.list;
    }
    deleteById(id){
      this.list.splice(id, 1);
    }
    updateById(id, val){
      this.list[id] = val;
    }
    replaceById(id, val){
      this.list[id] = val;
    }
  }
  let storage = new Storage();
  storage.add('hi boy');
  storage.add(1);
  storage.add(1);
  storage.getAll();
  storage.getById('1');
  storage.deleteById(1);
  storage.getAll();
  storage.updateById(0,'ыыы');
  storage.updateById(2,'ыыы');
  storage.replaceById(2,'ыыыыыыыыы');
  let arr = storage.getAll();
  console.log(arr);