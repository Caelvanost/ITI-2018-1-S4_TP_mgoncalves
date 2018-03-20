<template>
    <div>
        <div :class="type">
            <slot></slot>
        </div>
    </div>
</template>

<script>
export default {
    props: ['type']
}
</script>

<style>
    .success {
        color: green;
    }

    .error {
        color: red;
    }
</style>