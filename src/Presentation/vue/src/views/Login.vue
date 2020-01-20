<template>
    <v-content>
      <v-container fluid >
        <v-row align="center" justify="center">
          <v-col cols="12" sm="8" md="4" >
            <v-card class="elevation-12">
              <v-toolbar color="primary" dark flat >
                <v-toolbar-title>Login</v-toolbar-title>
                <v-spacer />
              </v-toolbar>
              <v-card-text>
                <v-form>
                  <v-text-field label="Login" v-model="userName" name="login" prepend-icon="fa-user" type="text" />
                  <v-text-field id="password" v-model="password" label="Password" name="password" prepend-icon="fa-lock" type="password" />
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer />
                <v-btn color="primary" @click="authenticate">Login</v-btn>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-content>
</template>

<script>
  import login from '../store/state/login';
  export default {
    name: 'login',
    methods: {
      async authenticate() {
        await login.actions.authenticate(this.userName, this.password);
        if(login.state.token !== undefined) {
          this.$router.push('task-list');
        }
      },
    },
    data: () => {
      return {
        userName: undefined,
        password: undefined
      }
    }
  }
</script>