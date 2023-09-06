import { yupResolver } from "@hookform/resolvers/yup";
import { Typography, Grid, TextField, Button, Alert } from "@mui/material";
import { useEffect } from "react";
import { Controller, useForm } from "react-hook-form";
import { LoginInputModel } from "../models/LoginModels";
import * as Yup from 'yup';
import { useData } from '../hooks/useData';
import { useRecoilState, useRecoilValue } from 'recoil';
import { LoginState } from "../state/Login.state";
import settings from "../settings";
import { DataHolderName, DataRecipientName } from "../state/Common.state";

export function LoginForm({ customerId }: { customerId: string }) {
    const { getCustomerByLoginId, submitCancelConsentRequest } = useData();
    const [loginState, setLoginState] = useRecoilState(LoginState);
    const defaultUserIds = settings.DEFAULT_USER_NAME_TEXT ?? "";
    const dataRecipientName = useRecoilValue(DataRecipientName);
    const dataHolderName = useRecoilValue(DataHolderName);

    const defaultFormValues: LoginInputModel = {
        customerId: "",
    };
    const validationSchema = Yup.object().shape({
        customerId: Yup.string().required('Customer ID is required'),
    });
    const {
        control,
        handleSubmit,
        setError,
        setValue
    } = useForm<LoginInputModel>({
        resolver: yupResolver(validationSchema),
        defaultValues: defaultFormValues,
        shouldUnregister: false
    });

    useEffect(() => {
        setValue('customerId', customerId);
    }, [customerId]);

    const onSubmit = async (data: LoginInputModel) => {
        //clearErrors();
        // Validate customer id
        const customer = await getCustomerByLoginId(data.customerId);
        if (customer === null) {
            setLoginState({ ...loginState, customerId: '', otp: '', customer: undefined });
            setError('customerId', { type: 'custom', message: 'Invalid Customer ID' });
            return;
        }

        setLoginState({ ...loginState, customerId: customer.LoginId, customer: customer });
    }

    const cancelRequest = () => {
        submitCancelConsentRequest();
    }

    const InfoPanel = () => (
        <>
            {defaultUserIds &&
                <Alert severity="info" sx={{ my: 2 }}>
                    <Typography variant="body2">
                        Your LoginID is LastName.Firstname -  eg <b>{defaultUserIds}</b>
                    </Typography>
                </Alert>}
        </>
    )

    return (
        <>
            <Typography color="inherit" variant="h5" pb={2}>
                Login
            </Typography>
            <Typography color="inherit" variant="body1">
                You've requested to share your data with<br />{dataRecipientName}<br />Enter your Login ID to continue.
            </Typography>
            <InfoPanel />
            <form onSubmit={handleSubmit(onSubmit)}>
                <Grid container rowSpacing={2} mt={1} mb={2}>
                    <Grid item xs={12}>
                        <Controller
                            name="customerId"
                            control={control}
                            rules={{ required: true }}
                            render={({ field: { onChange, value }, formState: { errors } }) => <TextField
                                label="Enter Customer ID - Required"
                                fullWidth
                                value={value}
                                onChange={onChange}
                                error={errors.customerId ? true : false}
                                helperText={errors.customerId?.message}
                                inputProps={{ tabIndex: 1 }}
                            />}
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <Typography color="inherit" variant="body2">
                            Having trouble with your details? Contact {dataHolderName} for assistance.
                        </Typography>
                    </Grid>
                    <Grid item xs={12}>
                        <Grid container spacing={2}>
                            <Grid item xs={6}>
                                <Button
                                    variant="outlined"
                                    color="primary"
                                    fullWidth
                                    size={'large'}
                                    tabIndex={2}
                                    aria-label="cancel"
                                    onClick={cancelRequest}
                                >
                                    Cancel
                                </Button>
                            </Grid>
                            <Grid item xs={6}>
                                <Button
                                    type='submit'
                                    variant="contained"
                                    color="primary"
                                    fullWidth
                                    size={'large'}
                                    // onClick={handleSubmit(onSubmit)}
                                    tabIndex={3}
                                    aria-label="continue"
                                >
                                    Continue
                                </Button>
                            </Grid>
                        </Grid>
                    </Grid>
                </Grid>
            </form>
        </>)
}