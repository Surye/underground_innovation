<template>
    <div class="col-sm-4 col-sm-offset-4">
        <h2>Registration</h2>
        <p>Register to participate in innovation.</p>
        <div class="alert alert-danger" v-if="error">
            <p>{{ error }}</p>
        </div>
        <div class="form-group">
            <label for="username">Username*</label>
            <input type="text"
                   id="username"
                   class="form-control"
                   placeholder="Enter your username"
                   required
                   v-model="registration.username">
        </div>
        <div class="form-group">
            <label for="password">Password*</label>
            <vue-password v-model="registration.password"
                          classes="input form-control" placeholder="Password"
                          :user-inputs="[registration.username]">
            </vue-password>
        </div>
        <div class="form-group">
            <vue-password v-model="registration.password_confirm"
                          classes="input form-control" placeholder="Confirm Password"
                          :user-inputs="[registration.username]">
            </vue-password>
        </div>
        <div class="form-group">
            <label for="email">E-Mail*</label>
            <input type="email"
                   id="email"
                   class="form-control"
                   placeholder="E-Mail"
                   required
                   v-model="registration.email">
        </div>
        <div class="form-group">
            <label for="unit">Unit*</label>
            <input type="text"
                   id="unit"
                   class="form-control"
                   placeholder="Enter your unit"
                   required
                   v-model="registration.unit">
        </div>
        <div class="form-group">
            <label for="name">Name</label>
            <input type="text"
                   id="name"
                   class="form-control"
                   placeholder="Enter your full name"
                   v-model="registration.name">
        </div>
        <div class="form-group">
            <label for="rank">Rank</label>
            <input type="text"
                   id="rank"
                   class="form-control"
                   placeholder="Enter your rank"
                   v-model="registration.rank">
        </div>

        <div class="form-group">
            <label for="phone">Phone Number</label>
            <input type="tel"
                   id="phone"
                   class="form-control"
                   placeholder="Enter your best constact phone number"
                   v-model="registration.phone">
        </div>
        <div class="form-group">
            <label>Interests:</label>
            <span v-for='interest in registration.interests' :key='interest.name'>
                <br />{{ interest.name }} <input type='checkbox'
                       :value='interest.name'
                       v-model='interest.checked'>
            </span>
        </div>
        <div class="form-group">
            <button class="btn btn-primary" @click="register()">Register Account</button>
        </div>
    </div>
</template>

<script>
    import Vue from 'vue'
    import auth from '../auth'
    import VuePassword from 'vue-password'

    Vue.component('vue-password', VuePassword)

    export default {
        data() {
            return {
                // We need to initialize the component with any
                // properties that will be used in it
                registration: {
                    username: '',
                    password: '',
                    password_confirm: '',
                    name: '',
                    rank: '',
                    phone: '',
                    email: '',
                    unit: '',
                    interests: [
                        { name: 'Drones', checked: false },
                        { name: 'Cyber Security', checked: false },
                        { name: 'Paranormal', checked: false }
                    ]
                },
                error: ''
            }
        },
        methods: {
            register() {
                var credentials = {
                    username: this.credentials.username,
                    password: this.credentials.password
                }
                // We need to pass the component's this context
                // to properly make use of http in the auth service
                auth.login(this, credentials, 'secretquote')
            }
        }

    }
</script>

<style>

</style>
