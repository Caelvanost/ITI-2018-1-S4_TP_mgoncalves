<template>
    <div>
        <div class="alert" :class="type">
            <slot></slot>
        </div>
    </div>
</template>

<script>
export default {
    props: ['type']
}
</script>

<style lang="scss" scoped>
.alert {
  font-weight: bold;
}
.success {
  color: green;
}

.error {
  color: red;
}
</style>