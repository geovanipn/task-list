<template>
    <v-content>
      <v-container>
        <v-card max-width="500" class="mx-auto" >
          <v-toolbar color="blue" dark>
            <v-icon class="ma-5">fa-list</v-icon>
            <v-toolbar-title>Lista de tarefas</v-toolbar-title>
            <v-spacer></v-spacer>
          </v-toolbar>
            <v-card-text>
              <v-form>
                <v-text-field v-model="title" required label="Título" type="text" />
                <v-text-field v-model="description" label="Descrição" type="text" />
                <v-row class="mr-1" justify="end">
                  <v-btn class="font-weight-bold" @click="addTask" color="blue white--text">
                    <v-icon color="white" left>fa-check</v-icon>
                    Adicionar
                  </v-btn>
                </v-row>
              </v-form>
            </v-card-text>
             <v-divider></v-divider>
          <v-list two-line>
              <template v-for="(item, index) in items">
                <v-list-item @click="changeStatus(item)" :key="item.id + item.title">
                  <template v-slot:default="{ active, toggle }">
                    <v-list-item-content>
                      <v-list-item-title v-text="item.title"></v-list-item-title>
                      <v-list-item-subtitle v-text="item.description"></v-list-item-subtitle>
                    </v-list-item-content>
                    <v-list-item-action>
                      <v-btn class="ma-1" x-small text icon color="red" @click="removeTask(item.id)">
                        <v-icon>fa-trash-alt</v-icon>
                      </v-btn>
                      <v-btn class="ma-1" v-if="item.status == 1" x-small text icon color="grey lighten-1">
                        <v-icon>fa-check</v-icon>
                      </v-btn>
                      <v-btn class="ma-1" v-else color="green" x-small text icon >
                        <v-icon>fa-check</v-icon>
                      </v-btn>
                    </v-list-item-action>
                  </template>
                </v-list-item>
                <v-divider v-if="index + 1 < items.length" :key="index"></v-divider>
              </template>
          </v-list>
        </v-card>
      </v-container>
  </v-content>
</template>


<script>
import task from '../store/state/task';
export default {
  name: 'task-list',
  methods: {
    addTask () {
      if(!this.title){
        return;
      }

      task.actions.create(this.title, this.description)
        .then(() => this.load())
        
        this.title = undefined;
        this.description = undefined;
    },
    changeStatus(taskItem) {
      if(taskItem.status == 1)
        taskItem.status = 2
      else if(taskItem.status == 2)
        taskItem.status = 1

      task.actions.update(taskItem)
        .then(() => this.load());
    },
    removeTask(id) {
      task.actions.delete(id)
        .then(() => this.load());
    },
    load() {
      task.actions.listagemm()
        .then((items) => this.items = items);
    }
  },
  mounted () {
    this.load();
  },
  data () {
    return {
      title: undefined,
      description: undefined,
      items: [],
    }
  }
}
</script>
<style lang="scss" scoped>


</style>